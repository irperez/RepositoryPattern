
//let item = '{ "detailID": "2901df8b-6da3-4164-1b8a-08d65f6ce171", "masterId": "0fad3a78-9c71-4622-2e06-08d65f6cdf21", "name": "", "someOtherName": "" }';

//alert(item);


//let item2 = {
//    detailID: "",
//    masterId: "",
//    name: "",
//    someOtherName: ""
//};
//alert(item2);

class DetailItem {
    constructor(id) {
        this.clientId = id;
        this.detailID = null;
        this.masterId = null;
        this.name = "";
        this.someOtherName = "";
    }

}

//let item3 = new DetailItem();
//alert(item3);


class Errors {

    constructor() {
        this.errors = []; // {}  this is not an array vs a blank object
        this.IsFormatedArrayOn = true;
    }

    get(field, myobject) {
        // console.log(myobject);
        //  console.dir(myobject);
        // console.log(field);
        if (this.IsFormatedArrayOn) {
            return this.findMessage(field);
        }
        else {
            if (this.errors[field]) {
                return this.errors[field][0];
            }
        }


    }

    //hasError(field) {

    //}


    getAllIndexes(arr, val) {
        var indexes = [], i;
        for (i = 0; i < arr.length; i++)
            if (arr[i] === val)
                indexes.push(i);
        return indexes;
    }

    clearTest(field) {

        console.log(field);
    }
    clear(field) {
        //  alert(field);

        let myitem = this.findMessage(field);

        if (myitem !== null) {
            this.errors = this.errors.filter(item => item.name !== field)
            //this.errors.remove(item);
            // console.log(this.errors);
        }


    }

    any() {
        return Object.keys(this.errors).length > 0;
    }

    isEmptyBob() {
        for (var key in this.errors) {
            if (this.errors.hasOwnProperty(key))
                return false;
        }
        return true;
    }


    getIndexed(fieldPrefix, fieldName, myobject, index) {

        // alert(index);
        //MDDetails[0].Name

        let key = fieldPrefix + "[" + index + "]." + fieldName;
        // console.log("key: " + key);

        //console.log(fieldPrefix);
        //console.log(fieldName);
        //console.log(index);
        //console.log(myobject);
        // console.log(myobject.name);
        //  alert(this.errors);

        // console.log(this.errors);

        if (this.IsFormatedArrayOn) {

            return this.findMessage(key);
        }
        else {
            if (this.errors[key]) {
                return this.errors[key][0];
            }

        }
    }

    clearByIndex(fieldPrefix, fieldName, myobject, index) {
        //   alert('clearByIndex');
        let key = fieldPrefix + "[" + index + "]." + fieldName;
        let myitem = this.findMessage(key);
        console.log(key);
        if (myitem !== null) {
            this.errors = this.errors.filter(item => item.name !== key)
            //this.errors.remove(item);
            // console.log(this.errors);
        }


    }

    findMessage(key) {

        if (this.any()) {

            let found = this.errors.find(function (element) {
                return element.name == key;
            });

            if (typeof found !== 'undefined') {
                console.log("found Item");
                console.log(found);
                // alert(found);
                return found.message;
            }





        }
    }

    record(errors) {
        // broken?  errors.forEach(err => console.log(err));
        console.log('all errors start');
        for (var propertyName in errors) {
            // propertyName is what you want
            // you can get the value like this: myObject[propertyName]
            console.log(propertyName)
            console.log(errors[propertyName])
        }
        console.log('all errors end');
        this.errors = errors;
        //let key = "DeptCode";
        //let found = this.errors.find(function (element) {
        //    return element.name == key;
        //});

        //alert(found);
        //debugger;
    }
}




let links = [
    'https://bootstrap-vue.js.org/docs/components/form-input/',
    'https://getbootstrap.com/docs/4.0/components/forms/#validation',
    'https://bootstrap-vue.js.org/docs/components/form/',
    'https://vuejs.org/v2/guide/list.html#v-for-with-v-if',
    'https://vuejs.org/v2/guide/list.html#key',
    'https://laracasts.com/series/learn-vue-2-step-by-step/episodes/19',
    'https://github.com/Nordes/HoNoSoFt.DotNet.Web.Spa.ProjectTemplates',
    'https://mathiasbynens.be/notes/shapes-ics',
    'https://mathiasbynens.be/notes/async-stack-traces',
];


 

let linksv3 = [];

function addLink(name, link) {

    let newLink = {
        name: name, link: link
    };

    linksv3.push(newLink);
}
addLink('bootstrap view', 'https://bootstrap-vue.js.org/docs/components/form-input/');
addLink('bootstrap validation', 'https://getbootstrap.com/docs/4.0/components/forms/#validation');
addLink('Asynchronous stack traces: why await beats Promise#then()', 'https://mathiasbynens.be/notes/async-stack-traces');

console.log(linksv3);
//var sample = [{ name: 'test', my: 'my value' }, {}, {} /*, ... */];

var app = new Vue({

    el: '#root',
    data: {
        links: links,
        
        linksv3: linksv3,
        nextId: 0,
        newName: '',
        names: ['Joe', 'Mary', 'Jane', 'Jack'],
        todos: [],
        errors: new Errors(),
        orginalTodos: '',
        myobjext: {
            firstName: 'John',
            lastName: 'Doe',
            age: 30
        }
    },

    mounted() {


        console.log('view is Mouted');

        // make an ajax request to the server https://localhost:44372/api/md


        let vm = this;  // not needed because of the arow function captures 'this'

        axios.get('/api/md').then(response => {
            this.setToDos(response.data);


        }).catch(error => {
            console.log(error);
        })
            .then()
        {
            // alert('then');
        };




        //// Make a request for a user with a given ID
        //axios.get('https://localhost:44372/api/md')
        //    .then(function (response) {
        //        // handle success

        //        console.log(response.data);
        //        //   debugger;

        //        // app. setMyData(response.data);

        //        vm.todos = response.data;
        //        console.log(vm.names);
        //    })
        //    .catch(function (error) {
        //        // handle error
        //        console.log(error);
        //    })
        //    .then(function () {
        //        // always executed
        //    });

    },
    computed: {
        onSubmit() {

        },
        incompletetasks() {
            // return this.errors.errors.filter(task =>  task.name.i);

            // return this.tasks.filter(function (task))
            // {
            //     return ! task.completed;
            // }

        }
    },
    methods: {
        //jsonCopyToString(src) {
        //    return JSON.stringify(src)  ;
        //},

        //jsonCopyToObject(src) {
        //return JSON.parse(JSON.stringify(src));
        //},

        setToDos(data) {
            // alert('test');
            this.todos = data;
            // this.todos.OriginalObject = JSON.stringify(data);
            //    alert(this.todos.OriginalObject);
        },
        clearForm() {

            this.todos.nametest = '';

            this.todos.mdDetails.forEach(item => {
                console.log(item);
                item.name = '';
            })

          //  delete this.errors;
        },
        addName() {
            //alert('add Name');
            this.names.push(this.newName);

            this.newName = '';
        },
        addNewDetailItem() {
            //alert('add Name');

            this.todos.mdDetails.push(new DetailItem(this.nextId++));


        },
        submitToApi() {

            let vm = this; // requreid if using the function syntax to caputre 'this'.
            axios.post('/api/MD', this.todos)
                .then(response => {
                    console.log('api-ok');


                    console.log(response);
                    this.setToDos(response.data);
                    console.log(response.data);
                    console.log('api-ok-end');
                })
                .catch(error => {
                    // alert('error');
                    console.log('error');
                    console.log(error);

                    //debugger;
                    console.log(error.data);
                    this.errors.record(error.data.errors)
                    // this.errors = error.response.data;
                });


            //let vm = this; // requreid if using the function syntax to caputre 'this'.
            //axios.post('/api/MD', this.todos)
            //    .then(function (response) {
            //        alert('ok');
            //        console.log(response);
            //    })
            //    .catch(function (error) {
            //        alert('error');
            //        console.log(error.data);
            //    });


        },
        deleteItem(item) {
            //alert('asdfads Name');
            //alert(item);
            item.isDeleted = true;
            // this.todos.mdDetails.push(new DetailItem());


        },
        reloadFromServer() {
        
            window.location.reload(true);
        }
    }
}
)
