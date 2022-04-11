using MarkovChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextGeneration
{
    public class TokenizedLibrary : IChainedLibrary
    {

        // TODO: библиотека, которая разделяет исходный на комфортные для генерации токены
        public MarkovChain<string> ChainedSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TokenizedLibrary(string source)
        {
            
        }
    }
}