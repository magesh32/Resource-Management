$(document).ready(function () {
    $('#ContentPlaceHolder1_submit').click(function () {
        var result = true;
        if ($('#ContentPlaceHolder1_TextBox1').val() === '') {
            $('#ContentPlaceHolder1_empnamevalidation').html('Name field cannot be blank');
            result = false;
        }
        if ($('#ContentPlaceHolder1_TextBox2').val() === '') {
            $('#ContentPlaceHolder1_emailvalidation').html('Email field cannot be blank');
            result = false;
        }
        //if ($('#ContentPlaceHolder1_TextBox2').val() != '' && !$('#ContentPlaceHolder1_TextBox2').val().indexOf('@ameexusa') < 1) {
        //    $('#ContentPlaceHolder1_emailvalidation').html('Email enetered is not valid');
        //    result = false;
        //}
        if ($('#ContentPlaceHolder1_DropDownList1').val() === '') {
            $('#ContentPlaceHolder1_techvalidation').html('framework field cannot be blank');
        }
        if ($('#ContentPlaceHolder1_DropDownList2').val() === '') {
            $('#ContentPlaceHolder2_rolevalidation').html('role field cannot be blank');
        }
        //if($('#ContentPlaceHolder1_
        return result;
    });
});