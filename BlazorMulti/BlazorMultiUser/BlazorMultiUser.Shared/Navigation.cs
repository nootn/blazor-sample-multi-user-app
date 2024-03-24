namespace BlazorMultiUser.Shared;

public static class Navigation
{
    public static class Url
    {
        public const string Auth = "/auth";
        public const string AccountAccessDenied = "/Account/AccessDenied";
        public const string AccountConfirmEmail = "/Account/ConfirmEmail";
        public const string AccountConfirmEmailChange = "/Account/ConfirmEmailChange";
        public const string AccountExternalLogin = "/Account/ExternalLogin";
        public const string AccountForgotPassword = "/Account/ForgotPassword";
        public const string AccountForgotPasswordConfirmation = "/Account/ForgotPasswordConfirmation";
        public const string AccountInvalidPasswordReset = "/Account/InvalidPasswordReset";
        public const string AccountInvalidUser = "/Account/InvalidUser";
        public const string AccountLockout = "/Account/Lockout";
        public const string AccountLogin = "/Account/Login";
        public const string AccountLoginWith2Fa = "/Account/LoginWith2fa";
        public const string AccountLoginWithRecoveryCode = "/Account/LoginWithRecoveryCode";
        public const string AccountManageChangePassword = "/Account/Manage/ChangePassword";
        public const string AccountManageDeletePersonalData = "/Account/Manage/DeletePersonalData";
        public const string AccountManageDisable2Fa = "/Account/Manage/Disable2fa";
        public const string AccountManageEmail = "/Account/Manage/Email";
        public const string AccountManageEnableAuthenticator = "/Account/Manage/EnableAuthenticator";
        public const string AccountManageExternalLogins = "/Account/Manage/ExternalLogins";
        public const string AccountManageGenerateRecoveryCodes = "/Account/Manage/GenerateRecoveryCodes";
        public const string AccountManage = "/Account/Manage";
        public const string AccountManagePersonalData = "/Account/Manage/PersonalData";
        public const string AccountManageResetAuthenticator = "/Account/Manage/ResetAuthenticator";
        public const string AccountManageSetPassword = "/Account/Manage/SetPassword";
        public const string AccountManageTwoFactorAuthentication = "/Account/Manage/TwoFactorAuthentication";
        public const string AccountRegister = "/Account/Register";
        public const string AccountRegisterConfirmation = "/Account/RegisterConfirmation";
        public const string AccountResendEmailConfirmation = "/Account/ResendEmailConfirmation";
        public const string AccountResetPassword = "/Account/ResetPassword";
        public const string AccountResetPasswordConfirmation = "/Account/ResetPasswordConfirmation";
        public const string Error = "/Error";
        public const string Home = "/";
        public const string CounterClientWasm = "/counter-client-wasm";
        public const string CounterClientSsr = "/counter-client-ssr";
        public const string CounterDatabase = "/counter-database";
        public const string Reports = "/reports";
        public const string GroupTasksServer = "/group-tasks/server";
    }
}