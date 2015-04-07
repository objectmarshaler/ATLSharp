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

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATLSharp
{
    /// <summary>
    /// The primary ATL Transformation Parser using the built in Antlr Grammar.
    /// </summary>
    public class ATLTransformationParser : IATLTransformationParser
    {
        #region Public Methods

        /// <summary>
        /// Parses the ATL from the given file, into a parse tree (syntax tree).
        /// </summary>
        /// <param name="filename">The name of the ATL transformation file</param>
        /// <returns>A parse tree (from the Antlr parser)</returns>
        public IParseTree Parse(string filename)
        {
            var content = File.ReadAllText(filename);
            return ParseString(content);
        }

        /// <summary>
        /// Parses the ATL from a given stream, into a parse tree (syntax tree).
        /// </summary>
        /// <param name="inStream">The input stream</param>
        /// <returns>A parse tree (from the Antlr parser)</returns>
        public IParseTree Parse(Stream inStream)
        {
            var stream = new AntlrInputStream(inStream);
            return Parse(stream);
        }

        /// <summary>
        /// Parses the ATL from a string, into a parse tree (syntax tree).
        /// </summary>
        /// <param name="content">The actual string content representing the ATL file</param>
        /// <returns>A parse tree (from the Antlr parser)</returns>
        public IParseTree ParseString(string content)
        {
            var stream = new AntlrInputStream(content);
            return Parse(stream);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// An internal method used to do the actual parsing from a special Antlr type of stream.
        /// </summary>
        /// <param name="stream">The special input stream from Antlr</param>
        /// <returns>A parse tree (from the Antlr parser)</returns>
        private IParseTree Parse(AntlrInputStream stream)
        {
            var lexer = new ATLLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ATLParser(tokens);

            if (parser.NumberOfSyntaxErrors > 0)
            {
                // If there are some errors detected while parsing the file, just throw a special exception
                throw new ATLException("Invalid ATL syntax.");
            }

            IParseTree tree = parser.unit();
            return tree;
        }

        #endregion
    }
}
