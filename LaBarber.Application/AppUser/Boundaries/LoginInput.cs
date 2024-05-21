﻿namespace LaBarber.Application.AppUser.Boundaries
{
    public class LoginInput
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginInput()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
