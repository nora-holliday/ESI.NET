﻿using ESI.NET.Models.Clones;
using ESI.NET.Models.SSO;
using System.Net.Http;
using System.Threading.Tasks;
using static ESI.NET.ApiRequest;

namespace ESI.NET.Logic
{
    public class ClonesLogic
    {
        private HttpClient _client;
        private ESIConfig _config;
        private AuthorizedCharacterData _data;
        private int character_id;

        public ClonesLogic(HttpClient client, ESIConfig config, AuthorizedCharacterData data = null)
        {
            _client = client;
            _config = config;
            _data = data;

            if (data != null)
                character_id = data.CharacterID;
        }

        /// <summary>
        /// /characters/{character_id}/clones/
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<Clones>> List()
            => await Execute<Clones>(_client, _config, RequestSecurity.Authenticated, RequestMethod.GET, $"/characters/{character_id}/clones/", token: _data.Token);

        /// <summary>
        /// /characters/{character_id}/implants/
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<int[]>> Implants()
            => await Execute<int[]>(_client, _config, RequestSecurity.Authenticated, RequestMethod.GET, $"/characters/{character_id}/implants/", token: _data.Token);
    }
}