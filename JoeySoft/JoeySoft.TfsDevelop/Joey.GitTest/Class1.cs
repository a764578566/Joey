using Joey.Git;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Joey.GitTest
{

    public class GitTest
    {
        [Fact]
        public void Test1()
        {
            GitHelper git = new GitHelper();
            Assert.Empty("");
        }

    }
}
