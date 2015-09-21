$(document).ready(function () {
    $('#ContentPlaceHolder1_submit').click(function () {
        var result = true;
        if ($('#ContentPlaceHolder1_emp_id1').val() === '') {
            $('#ContentPlaceHolder1_empid').html('Id field cannot be blank');
            result = false;
        }
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
        if ($('#ContentPlaceHolder1_TextBox3').val() === '') {
            $('#ContentPlaceHolder1_pwdvalidation').html('password field cannot be blank');
            result = false;
        }
        
       //if ($('#ContentPlaceHolder1_TextBox3').val() != ('#ContentPlaceHolder_TextBox4').val()) {
       //    $('#ContentPlaceHolder2_cnfpwdvalidation').html('Password does not match');
       //    result = false;
       //}
           
        return result;
    });
  
});
