Imports System.ComponentModel.Composition
Imports System.Reflection
Imports System.Web.Compilation
Imports System.Web.Optimization
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Web.Infrastructure.DynamicModuleHelper
Imports NRepository.UniversityBL.BL
Imports SimpleInjector
Imports SimpleInjector.Advanced
Imports SimpleInjector.Diagnostics
Imports SimpleInjector.Integration.Web
Imports University.Data

<Assembly: PreApplicationStartMethod(GetType(NRepository.Webforms.VB.PageInitializerModule), "Initialize")>
Public NotInheritable Class PageInitializerModule
    Implements IHttpModule

    Public Shared Sub Initialize()
        DynamicModuleUtility.RegisterModule(GetType(PageInitializerModule))
    End Sub

    Sub Init(app As HttpApplication) Implements IHttpModule.Init
        AddHandler app.PreRequestHandlerExecute, Sub(sender, e)
                                                     Dim handler = app.Context.CurrentHandler
                                                     If (handler IsNot Nothing) Then
                                                         Dim name = handler.GetType().Assembly.FullName

                                                         If (Not name.StartsWith("System.Web") AndAlso Not name.StartsWith("Microsoft")) Then
                                                             Global_asax.InitializeHandler(handler)
                                                         End If
                                                     End If

                                                 End Sub
    End Sub

    Sub Dispose() Implements IHttpModule.Dispose

    End Sub
End Class
Public Class Global_asax
    Inherits HttpApplication

    Public Shared container As Container

    Sub Application_Start(sender As Object, e As EventArgs)
        Bootstrap()
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

    Public Shared Sub InitializeHandler(ByVal handler As IHttpHandler)
        If TypeOf handler Is Page Then
            Global_asax.InitializePage(CType(handler, Page))
        End If
    End Sub

    Private Shared Sub InitializePage(ByVal page As Page)
        container.GetRegistration(page.GetType(), True).Registration.InitializeInstance(page)
        AddHandler page.InitComplete, Sub()
                                          Global_asax.InitializeControl(page)
                                      End Sub
    End Sub

    Private Shared Sub InitializeControl(ByVal control As Control)
        If TypeOf control Is UserControl Then
            container.GetRegistration(control.[GetType](), True).Registration.InitializeInstance(control)
        End If

        For Each child As Control In control.Controls
            Global_asax.InitializeControl(child)
        Next
    End Sub

    Public Shared Sub Bootstrap()
        ' 1. Create a New Simple Injector container
        Dim container = New Container()
        container.Options.DefaultScopedLifestyle = New WebRequestLifestyle()

        ' Register a custom PropertySelectionBehavior to enable property injection
        container.Options.PropertySelectionBehavior = New ImportAttributePropertySelectionBehavior()

        ' 2. Configure the container (register)
        container.Register(Of ICourseRepository, CourseRepository)(Lifestyle.Scoped)
        container.Register(Of CourseProvider)(Lifestyle.Scoped)
        container.Register(Of DbContext, UniversityContext)(Lifestyle.Scoped)
        container.Register(Of DbContextOptions(Of UniversityContext))(
            Function()
                Return New DbContextOptionsBuilder(Of UniversityContext)().UseSqlServer("Server=localhost;Database=TestDB;Trusted_Connection=True;").Options
            End Function, Lifestyle.Scoped)

        ' Register your Page classes to allow them to be verified and diagnosed.
        RegisterWebPages(container)

        ' 3. Store the container for use by Page classes
        Global_asax.container = container

        container.Verify()

        Dim i = 0
    End Sub

    Private Shared Sub RegisterWebPages(container As Container)
        Dim pageTypes = From assembly In BuildManager.GetReferencedAssemblies().Cast(Of Assembly)()
                        Where Not assembly.IsDynamic
                        Where Not assembly.GlobalAssemblyCache
                        From type In assembly.GetExportedTypes()
                        Where type.IsSubclassOf(GetType(Page)) OrElse type.IsSubclassOf(GetType(UserControl))
                        Where Not type.IsAbstract AndAlso Not type.IsGenericType
                        Select type

        For Each type As Type In pageTypes
            Dim reg = Lifestyle.Transient.CreateRegistration(type, container)
            reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "ASP.NET creates and disposes page classes for us.")
            container.AddRegistration(type, reg)
        Next

    End Sub

    Class ImportAttributePropertySelectionBehavior
        Implements IPropertySelectionBehavior

        Public Function SelectProperty(implementationType As Type, propertyInfo As PropertyInfo) As Boolean Implements IPropertySelectionBehavior.SelectProperty
            ' Makes use of the System.ComponentModel.Composition assembly
            Return (GetType(Page).IsAssignableFrom(implementationType) OrElse GetType(UserControl).IsAssignableFrom(implementationType)) AndAlso propertyInfo.GetCustomAttributes(GetType(ImportAttribute), True).Any()
        End Function
    End Class
End Class
