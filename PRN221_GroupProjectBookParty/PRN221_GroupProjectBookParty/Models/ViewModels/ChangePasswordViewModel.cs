namespace PRN221_GroupProjectBookParty.Models.ViewModels;

public class ChangePasswordViewModel
{
    public int Id { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}