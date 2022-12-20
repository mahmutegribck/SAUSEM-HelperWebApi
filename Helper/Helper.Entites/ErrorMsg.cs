using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Entites
{
    public static class ErrorMsg
    {
        public const string None = "";
        public const string InvalidProperties = "Some properties are not valid";
        public const string InvalidUser = "User not found.";
        public const string EmailNotConfirm = "Email address has not confirm.";
        public const string NoUserEmail = "No user associated with email";
        public const string ResetPasswordSuccess = "Reset password URL has been sent to the email successfully!";
        public const string InvalidPassword = "Invalid password";
        public const string NullModel = "Reigster Model is null";
        public const string UserNotCreated = "User did not create";
        public const string GeneralErrorMsg = "Something went wrong";

    }

    public static class Msg
    {
        public const string ResetPasswordSuccess = "Password has been reset successfully!";
        public const string EmailConfirm = "Email confirmed successfully!";
        public const string ConfirmPasswordNotMatch = "Confirm password doesn't match the password";
        public const string ConfirmEmailMsg = "Confirm your email";
        public const string EmailMsgBody1 = "Welcome to DSV Central User Authentication Database.";
        public const string EmailMsgBody2 = "Please confirm your email by ";
        public const string EmailMsgBody3 = "Clicking here.";
        public const string UserCreated = "User created successfully!";
        public const string ResetPassword = "Reset Password";

    }
}
