using System;
using System.Net;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// Provides common methods for sending data to and receiving data from a resource identified by a URI
    /// </summary>
    public partial class NopWebClient : WebClient
    {
        /// <summary>
        /// The length of time, in milliseconds, before the request times out
        /// </summary>
        private readonly int? _timeout;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="timeout">Length of time, in milliseconds, before the request times out. Set null to use default value</param>
        public NopWebClient(int? timeout)
        {
            _timeout = timeout;
        }

        /// <summary>
        /// Returns a System.Net.WebRequest object for the specified resource
        /// </summary>
        /// <param name="address">A System.Uri that identifies the resource to request</param>
        /// <returns>A new System.Net.WebRequest object for the specified resource</returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);

            if (request != null && _timeout != null)
                request.Timeout = _timeout.Value;

            return request;
        }
    }
}
