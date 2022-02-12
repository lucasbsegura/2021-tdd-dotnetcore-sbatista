using Xunit;

namespace CursoOnline.Dominio.Test.Outros
{
    public class MeuPrimeiroTeste
    {
        [Fact]
        public void ValoresInteirosDevemSerIguais()
        {
            /// A A A 
            /// 3 A's

            /// A for Arrange (Organize)
            var variavel1 = 1;
            var variavel2 = 2;

            /// A for Act (Ação)
            variavel2 = variavel1;

            /// A for Assert
            //Assert.Equal(variavel1, variavel2);
            //Assert.Contains();
            Assert.True(variavel1 == variavel2);
        }
    }
}
