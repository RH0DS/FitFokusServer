﻿namespace FitfokusServer.Models.DTOs.Requests;

    public class CreateUserRequestDTO
    {
    public string? GoogleId { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool Verified { get; set; } = false;

}
