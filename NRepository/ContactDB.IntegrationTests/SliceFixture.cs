 
using EvitiContact.ContactModel;
using eviti.data.tracking.BaseObjects;
using eviti.data.tracking.DIHelp;
using eviti.data.tracking.Interfaces;
using eviti.Data.Tracking.BaseObjects;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NRepository.RazorPages;

namespace ContactDB.IntegrationTests
{
    public class SliceFixture
    {
        private static readonly Checkpoint _checkpoint;
        private static readonly IConfigurationRoot _configuration;
        private static readonly IServiceScopeFactory _scopeFactory;
        private static readonly string ConnectionString;


        //public static ServiceProvider StaticServiceProvider { get; private set; }

        static SliceFixture()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            var provider = services.BuildServiceProvider();

            ServiceLocator.AppServiceProvider = provider;
            _scopeFactory = provider.GetService<IServiceScopeFactory>();

            //IStateService stateService = StaticServiceProvider.GetService<IStateService>();
            // var dummy = stateService.GetStateByAbbreviation("DE");

            EvitiContact.Application.ApplicationSetup.SetupApp(provider);
            ConnectionString = _configuration.GetConnectionString("UniversityDB");

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[]
                {
                    "sysdiagrams",
                    "__EFMigrationsHistory",
                    "LookupStuff",
                    "aspnet_Applications",
                    "ContactRole",
                    "ContactSecurityAreas",
                    "ContactSecurityQuestions",
                    "ContactSecurityRoles",
                    "ContactSecuritySchema",
                    "ContactType",
                    "ContactUserOptionTypes",
                    "States",
                    "ZipCodes",
                },
                //SchemasToExclude = new[]
                //{
                //    "someSchema"
                //}
            };
        }

        public static Task ResetCheckpoint()
        {
            return _checkpoint.Reset(ConnectionString);
        }

        public static void ResetCheckpointSync()
        {
            Task t = _checkpoint.Reset(ConnectionString);

            t.GetAwaiter().GetResult();


        }


        public static async Task ExecuteScopeAsyncBobNoDB(Func<IServiceProvider, Task> action)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                //var dbContext = scope.ServiceProvider.GetService<ContactModelDbContext>();

                try
                {
                    //dbContext.LogMyId();
                    //await dbContext.BeginTransactionAsync().ConfigureAwait(false);

                    await action(scope.ServiceProvider).ConfigureAwait(false);

                    //await dbContext.CommitTransactionAsync().ConfigureAwait(false);
                }
                catch (Exception)
                {
                    //dbContext.RollbackTransaction();
                    throw;
                }
            }
        }

        public static async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ContactModelDbContext>();

                try
                {
                    //   dbContext.LogMyId();
                    await dbContext.BeginTransactionAsync().ConfigureAwait(false);

                    await action(scope.ServiceProvider).ConfigureAwait(false);

                    await dbContext.CommitTransactionAsync().ConfigureAwait(false);
                }
                catch (Exception)
                {
                    dbContext.RollbackTransaction();
                    throw;
                }
            }
        }

        public static async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ContactModelDbContext>();

                try
                {
                    await dbContext.BeginTransactionAsync().ConfigureAwait(false);

                    var result = await action(scope.ServiceProvider).ConfigureAwait(false);

                    await dbContext.CommitTransactionAsync().ConfigureAwait(false);

                    return result;
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    dbContext.RollbackTransaction();
                    throw;
                }
            }
        }

        public static Task ExecuteDbContextAsync(Func<ContactModelDbContext, Task> action)
        {
            return ExecuteScopeAsync(sp => action(sp.GetService<ContactModelDbContext>()));
        }


        public static Task ExecuteDbContextAsync(Func<ContactModelDbContext, IMediator, Task> action)
        {
            return ExecuteScopeAsync(sp => action(sp.GetService<ContactModelDbContext>(), sp.GetService<IMediator>()));
        }

        public static Task<T> ExecuteDbContextAsync<T>(Func<ContactModelDbContext, Task<T>> action)
        {
            return ExecuteScopeAsync(sp => action(sp.GetService<ContactModelDbContext>()));
        }

        public static Task<T> ExecuteDbContextAsync<T>(Func<ContactModelDbContext, IMediator, Task<T>> action)
        {
            return ExecuteScopeAsync(sp => action(sp.GetService<ContactModelDbContext>(), sp.GetService<IMediator>()));
        }

        public static Task InsertAsync<T>(params T[] entities) where T : class
        {
            return ExecuteDbContextAsync(db =>
            {
                foreach (var entity in entities)
                {
                    db.Set<T>().Add(entity);
                }
                return db.SaveChangesAsync();
            });
        }

        public static Task InsertAsync<TEntity>(TEntity entity) where TEntity : class, IClientChangeTracker
        {
            return ExecuteDbContextAsync(db =>
            {
                //db.Set<TEntity>().Attach(entity);

                //   db.LogMyId();

                db.AttachOnly(entity);
                return db.SaveChangesAsync();
            });
        }

        public static Task InsertAsync<TEntity, TEntity2>(TEntity entity, TEntity2 entity2)
            where TEntity : class
            where TEntity2 : class
        {
            return ExecuteDbContextAsync(db =>
            {
                //    db.LogMyId();
                db.Set<TEntity>().Add(entity);
                db.Set<TEntity2>().Add(entity2);

                return db.SaveChangesAsync();
            });
        }

        public static Task InsertAsync<TEntity, TEntity2, TEntity3>(TEntity entity, TEntity2 entity2, TEntity3 entity3)
            where TEntity : class
            where TEntity2 : class
            where TEntity3 : class
        {
            return ExecuteDbContextAsync(db =>
            {
                //    db.LogMyId();
                db.Set<TEntity>().Add(entity);
                db.Set<TEntity2>().Add(entity2);
                db.Set<TEntity3>().Add(entity3);

                return db.SaveChangesAsync();
            });
        }

        public static Task InsertAsync<TEntity, TEntity2, TEntity3, TEntity4>(TEntity entity, TEntity2 entity2, TEntity3 entity3, TEntity4 entity4)
            where TEntity : class
            where TEntity2 : class
            where TEntity3 : class
            where TEntity4 : class
        {
            return ExecuteDbContextAsync(db =>
            {
                //db.LogMyId();
                db.Set<TEntity>().Add(entity);
                db.Set<TEntity2>().Add(entity2);
                db.Set<TEntity3>().Add(entity3);
                db.Set<TEntity4>().Add(entity4);

                return db.SaveChangesAsync();
            });
        }

        public static Task<T> FindAsync<T>(Guid id)
            where T : class, IHaveIdentifier2<Guid>
        {
            // return ExecuteDbContextAsync(db => db.Set<T>().FindAsync(id));

            return ExecuteDbContextAsync(db =>
            {
                string t = string.Empty;
                var result = db.Set<T>().FindAsync(id);
                t = string.Empty;

                return result;
            });
        }

        public static Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            return ExecuteScopeAsync(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

        public static Task SendAsync(IRequest request)
        {
            return ExecuteScopeAsync(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

        private static int CourseNumber = 1;

        public static int NextCourseNumber()
        {
            return Interlocked.Increment(ref CourseNumber);
        }

        public static Task ExecuteDbContextBobAsync(Func<ContactModelDbContext, IServiceProvider, IMediator, Task> action)
        {
            return ExecuteScopeAsync(sp => action(sp.GetService<ContactModelDbContext>(), sp, sp.GetService<IMediator>()));
        }


        /// <summary>
        /// This mehtod exist so we can wrap calls in a scope so the DB context does not result in a singleton
        /// I don't fully understand function pointers as of yet
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Task ExecuteBobScopedServiceProfiderAsync(Func<IServiceProvider, Task> action)
        {
            return ExecuteScopeAsyncBobNoDB(sp => action(sp));
        }

        // this is 
        public static Task ExecuteBobScopedServiceProfiderAndContactDBContextAsync(Func<IServiceProvider, ContactModelDbContext, Task> action)
        {
            return ExecuteScopeAsyncBobNoDB(sp => action(sp, sp.GetService<ContactModelDbContext>()));
        }

    }
}
