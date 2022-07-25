using Internal.Audit.Application.Contracts.Auth;
using Internal.Audit.Application.Models;
using Newtonsoft.Json;

namespace Internal.Audit.Api.Services
{
    public class GoogleRecatchaVerificationService : IGoogleRecatchaVerificationService
    {
        private string _captchaSecretKey;
        private string _captchaVerificationUrl;
        public GoogleRecatchaVerificationService(IConfiguration configuration)
        {
            _captchaSecretKey = configuration.GetValue<string>("GoogleReCaptcha:V2SecretKey");
            _captchaVerificationUrl = configuration.GetValue<string>("GoogleReCaptcha:VerificationUrl");
        }
        public async Task<(bool, string)> ValidateRecaptchaV2(string token)
        {
            var dictionary = new Dictionary<string, string>
                    {
                        { "secret", _captchaSecretKey },
                        { "response", token }
                    };

            var postContent = new FormUrlEncodedContent(dictionary);

            HttpResponseMessage recaptchaResponse = null;
            string stringContent = "";

            // Call recaptcha api and validate the token
            using (var http = new HttpClient())
            {
                recaptchaResponse = await http.PostAsync(_captchaVerificationUrl, postContent);
                stringContent = await recaptchaResponse.Content.ReadAsStringAsync();
            }

            if (!recaptchaResponse.IsSuccessStatusCode)
            {
                return (false, "Unable to verify recaptcha token");
            }

            if (string.IsNullOrEmpty(stringContent))
            {
                return (false, "Invalid reCAPTCHA verification response");
            }

            var googleReCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(stringContent);

            if (!googleReCaptchaResponse.Success)
            {
                var errors = string.Join(",", googleReCaptchaResponse.ErrorCodes);

                return (false, "Invalid reCAPTCHA verification response");
            }


            if (googleReCaptchaResponse.Score < 0.5)
            {
                return (true, "This is a potential bot. Signup request rejected");
            }
            return (true, "ReCaptcha Verified");
        }
    }
}
