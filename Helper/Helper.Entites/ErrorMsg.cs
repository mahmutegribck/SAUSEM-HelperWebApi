using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Entites
{
    public static class ErrorMsg
    {
        public const string None = "";
        public const string InvalidProperties = "Bazı Özellikler Geçerli Değil";
        public const string InvalidUser = "Kullanıcı Bulunamadı";
        public const string EmailNotConfirm = "Mail Adresi Hatalı";
        public const string NoUserEmail = "Mail Adresine Ait Kullanıcı Bulunamadı";
        public const string ResetPasswordSuccess = "Reset password URL has been sent to the email successfully!";
        public const string InvalidPassword = "Şifre Hatalı";
        public const string NullModel = "Reigster Model is null";
        public const string UserNotCreated = "Kullanıcı Oluşturulamadı";
        public const string GeneralErrorMsg = "Something went wrong";

    }

    public static class Msg
    {
        public const string ResetPasswordSuccess = "Şifre Başarılı Bir Şekilde Değiştirildi";
        public const string EmailConfirm = "Email confirmed successfully!";
        public const string ConfirmPasswordNotMatch = "Confirm password doesn't match the password";
        public const string ConfirmEmailMsg = "Confirm your email";
        public const string EmailMsgBody1 = "Welcome to DSV Central User Authentication Database.";
        public const string EmailMsgBody2 = "Please confirm your email by ";
        public const string EmailMsgBody3 = "Clicking here.";
        public const string UserCreated = "User created successfully!";
        public const string ResetPassword = "Reset Password";
        public const string LoginSucces = "Giriş Başarıyla Gerçekleşti";

    }
}
