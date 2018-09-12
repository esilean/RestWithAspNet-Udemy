using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace RestfulAspNetCore.Application.Configuration.Token
{
    public class SigningConfigurations
    {

        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations(string secret)
        {
            //Outro exemplo para gerar a Key, atraves de um segredo informado
            //using (var provider = new RSACryptoServiceProvider(2048))
            //{
            //    Key = new RsaSecurityKey(provider.ExportParameters(true));
            //}
            //SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

            var symmetricKeyAsBase64 = secret;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            Key = new SymmetricSecurityKey(keyByteArray);
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }

    }
}
