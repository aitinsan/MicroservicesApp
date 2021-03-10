using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Application.Models
{
    public abstract class ResponseBase
    {
        public ResponseBase()
        {
            this.Errors = this.EmptyErros();
        }

        public bool Success
        {
            get
            {
                return this.Errors != null && !this.Errors.Any();
            }
        }

        public IDictionary<string, string> Errors { get; set; }

        protected IDictionary<string, string> EmptyErros() => new Dictionary<string, string>();
    }
}
