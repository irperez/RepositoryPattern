// This code will hijack the form submit, encode the form collection as x-www-form-urlencoded
// if the form passes validation the server will response with a json message as to what page
// the client should redirect to.  Otherwise the items that fail validation will be iterated
// and highlighted.  it will also populate a validation summary.   Thjs method requires the server 
// to also support sending the model state as json back to the calling client.  

// It needs lodash.js

// this sample has been updated to support jquery 3.x to the best of my ability


// Any javacript errors may cause a double submit in the ajax function. 

// to use see the ValidatorPageFilter class


// See Jimmy Bogard's razor pages core sample as well as google for this "building-mvc-jimmy-style".
// The link below does not seam to work anymore. 
// 
//https://thefreezeteam.azurewebsites.net/2015/08/10/building-mvc-jimmy-style/
var highlightFields = function (response) {

    $('.form-group').removeClass('has-error');
    //  alert('highlightFields');
    $.each(response, function (propName, val) {
        //alert(propName);
        //alert(val);
        var nameSelector = '[name = "' + propName.replace(/(:|\.|\[|\])/g, "\\$1") + '"]',
            idSelector = '#' + propName.replace(/(:|\.|\[|\])/g, "\\$1");


        var $el = $(nameSelector) || $(idSelector);




        if (val.Errors.length > 0) {
            var bob = $(nameSelector) || $(idSelector);
            // alert('prop name'); alert(propName); alert(val); 
            console.log('prop name');
            console.log(propName);
            console.log('nameSelector: ' + nameSelector);
            console.log('idSelector: ' + idSelector);
            console.log(val);




            // $el.css("background-color", "red");
            $el.closest('.form-group').addClass('has-error');
        }
    });
};
var highlightErrors = function (xhr) {
    try {
        var data = JSON.parse(xhr.responseText);

        highlightFields(data);
        showSummary(data);
        window.scrollTo(0, 0);
    } catch (e) {
        // (Hopefully) caught by the generic error handler in `config.js`.
    }
};
var showSummary = function (response) {

    var validationSummaryKey = '#validationSummary';

    if ($(validationSummaryKey).length==0) {
        alert("The validationSummary is missing.");
    }
    //if ($('#validationSummary').length) {
    //    alert("The element you're testing (validationSummary) is present.");
    //}
    //alert('showSummary1');
    $(validationSummaryKey).empty().removeClass('hidden');
    //alert('showSummary2');

 
 

    var verboseErrors = _.flatten(_.map(response, 'Errors')),
        errors = [];


    var nonNullErrors = _.reject(verboseErrors, function (error) {
        return error.ErrorMessage.indexOf('must not be empty') > -1;
    });

    _.each(nonNullErrors, function (error) {

        console.log("Summary: " + error.ErrorMessage);
        console.log(error);

        errors.push(error.ErrorMessage);
    });
    //alert(nonNullErrors);
    //alert(verboseErrors);

    //if (nonNullErrors.length !== verboseErrors.length) {
    //    errors.push('The highlighted fields are required to submit this form.');
    //}

    if (errors.length > 0) {
         
        var $ul = $(validationSummaryKey).append('<p>Please review the highlighted fields for errors.</p>').append('<ul></ul>');

        _.each(errors, function (error) {
           // alert(error);
            var $li = $('<li></li>').text(error);
            $li.appendTo($ul);
        });
    }
};

var redirect = function (data) {
    console.log(data);
    console.dir(data);
    //alert('redirect');
    //alert(data);

    var test = JSON.stringify(data);
    alert("redirecting to: " + test);
   // return;

    if (data.redirect) {
        window.location = data.redirect;
    } else {
        window.scrollTo(0, 0);
        window.location.reload();
    }
};

$('form[method=post]').not('.no-ajax').on('submit', function () {
    var submitBtn = $(this).find('[type="submit"]');
    //alert('bobtest');
    submitBtn.prop('disabled', true);
    $(window).unbind();

    var $this = $(this),
        formData = $this.serialize();

    //    alert(formData);
    console.log(formData);
    console.dir(formData);
    $this.find('div').removeClass('has-error');

    var test = $this.attr('action');


    //$.ajax({
    //    type: "POST",
    //    url: $this.attr('action'),
    //    data: formData
    //}).done(function () {
    //    alert("Success.");
    //    }).fail(highlightErrors).always(function () {
    //        alert("complete");
    //    });; 



    // alert(test);
    $.ajax({
        url: $this.attr('action'),
        type: 'post',
        data: formData,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        //  dataType: 'json',
        statusCode: {
            200: redirect
        }
    }).always(function () {
        // alert("always");
        submitBtn.prop('disabled', false);
    })
        .fail(highlightErrors);
    // alert('end of function');
    return false;
});
