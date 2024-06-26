namespace Register_LoginAPI_with_JWT
{
    public class User
    {
        public string username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }= Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; }=Array.Empty<byte>();
    }
}
