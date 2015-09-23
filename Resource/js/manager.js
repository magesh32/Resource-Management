//$(document).ready(function () {
//    $("#menu ul li a").hover(function () { $(this).css({ "color": "red" }); }, function () { $(this).css({ "color": "orange" }); });
//});


$(document).ready(function () {
    $('#ContentPlaceHolder1_btn1').click(function () {
        var result = true;
        if ($('#ContentPlaceHolder1_pro_name1').val() === '') {
            $('#ContentPlaceHolder1_proname').html('Projectname field cannot be blank');
            result = false;
        }
        if ($('#ContentPlaceHolder1_cliname1').val() === '') {
            $('#ContentPlaceHolder1_client').html('Client name field cannot be blank');
            result = false;
        }
        if ($('#ContentPlaceHolder1_duration').val() === '') {
            $('#ContentPlaceHolder1_durat').html('Duration field cannot be blank');
            result = false;
        }     
        if ($('#ContentPlaceHolder1_sdate1').val() === '') {
            $('#ContentPlaceHolder1_sdating').html('Please select the start date');
            result = false;
        }
        if ($('#ContentPlaceHolder1_edate1').val() === '') {
            $('#ContentPlaceHolder1_edating').html('Please select the end date');
            result = false;
        }
        return result;
    });  

    $('form').submit(function (event) {
        var isValid = true;
        $('.capacity').each(function () {
            var maxCapacity = parseInt($(this).attr('maxcapacity'));
            var currentCapacity = parseInt($(this).val());
            $(this).parent().parent().find('.error').remove();
            if (!(currentCapacity <= maxCapacity)) {
                isValid = false;
                $(this).css({
                    "border": "1px solid red",
                    "background": "#FFCECE"
                });                
                $(this).parent().append(' <span class="error">Please enter a value within ' + maxCapacity + ' </span>')
                
            }
            else
            {
                $(this).css({
                    "border": "",
                    "background": ""
                });
            }
        });

        if(!isValid)
            event.preventDefault();
    });
    $("#menu ul a").each(function (index) {
        if (this.href.trim() == window.location)
            $(this).addClass("style1");
    });
    var capacityCntrl = $('.capacity');
    if (capacityCntrl && capacityCntrl.length > 0) {
        var divPosition = $('#tblListBox').offset();
        $('html, body').animate({ scrollTop: divPosition.top }, "fast");
    }
  
});

