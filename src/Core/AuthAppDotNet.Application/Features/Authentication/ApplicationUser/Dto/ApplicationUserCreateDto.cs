namespace AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto
{
    public sealed class ApplicationUserCreateDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; } = 1;
        public bool IsAdmin { get; set; }
    }
}
