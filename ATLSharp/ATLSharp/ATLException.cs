/*
Copyright 2015 Spikes N.V.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

Initially developed in the context of ARTIST EU project www.artist-project.eu
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATLSharp
{
    /// <summary>
	/// Represents an exception that is thrown when invalid ATL Syntax is encountered by the parser
	/// </summary>
	public class ATLException : Exception
    {
        #region Variables

        private string _message;

        #endregion

        #region Creators

        /// <summary>
        /// Initializes a new instance of the InvalidATLException class with an empty message
        /// </summary>
        public ATLException()
        {
            _message = "";
        }

        /// <summary>
        /// Initializes a new instance of the InvalidATLException class with the given message
        /// </summary>
        /// <param name="message">A string describing a reason for the exception</param>
        public ATLException(string message)
        {
            _message = message;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a message describing the exeption or an empty string
        /// </summary>
        public override string Message
        {
            get
            {
                return _message;
            }
        }

        #endregion
    }
}
