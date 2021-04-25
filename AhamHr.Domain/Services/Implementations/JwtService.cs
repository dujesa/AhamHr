using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Constants;
using AhamHr.Domain.Models.Configurations;
using AhamHr.Domain.Repositories.Interfaces;
using AhamHr.Domain.Services.Interfaces;
using Jose;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private static DateTime GetUtcBaseDateTime => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static double GetCurrentSeconds => (DateTime.UtcNow - GetUtcBaseDateTime).TotalSeconds;

        public const JwsAlgorithm Algorithm = JwsAlgorithm.HS256;

        public JwtService(
            IOptions<JwtConfiguration> jwtConfigurationOptions,
            IUserRepository userRepository
        ) {
            _jwtConfiguration = jwtConfigurationOptions.Value;
            _userRepository = userRepository;
        }

        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IUserRepository _userRepository;

        public string GetJwtTokenForUser(User user)
        {
            var expiresAt = GetCurrentSeconds + _jwtConfiguration.ExpiryMinutes * 60;
            var payload = new Dictionary<string, string>
            {
                {"iss", _jwtConfiguration.Issuer},
                {"aud", _jwtConfiguration.AudienceId},
                {"exp", expiresAt.ToString(CultureInfo.InvariantCulture)},
                {Claims.UserId, user.Id.ToString()},
                {Claims.Role, user.UserRole.ToString()}
            };

            return JWT.Encode(payload, _jwtConfiguration.GetAudienceSecretBytes(), Algorithm);
        }

        public string GetNewToken(string token)
        {
            var decodedToken = JWT.Decode(token, _jwtConfiguration.GetAudienceSecretBytes());
            var decodedJObjectToken = (JObject)JsonConvert.DeserializeObject(decodedToken);
            var expiryTime = decodedJObjectToken["exp"].ToObject<double>();
            if (GetCurrentSeconds - expiryTime > _jwtConfiguration.ExpiryMinutes * 60)
                return null;

            var userId = decodedJObjectToken[Claims.UserId].ToObject<int>();

            var user = _userRepository.GetUser(userId);
            return GetJwtTokenForUser(user);
        }
    }
}
