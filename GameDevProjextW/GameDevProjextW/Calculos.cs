using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*As valores das contas serão aumentado e diminuido com se e senão posteriormente conforme necessidades*/
namespace GameDevProjextW
{
    class Calculos
    {
        private Int32 erro = 0;
        private Int32 design = 0;
        private Int32 tecnologia = 0;
        private Int32 pesquisa = 0;

        private int starGames;
        private int informedgamer;
        private int gameHero; //apos mostrar as avaliações é necessario zerar*****
        private int allGames;

        public void calcula_Tema_Genero_Plataforma_grafico(double tema, double genero, double plataforma, double pesquisa)
        {//Criando o jogo com configurações iniciais
            for (int i = 0; i < 5; i++)
            {
                erro = erro + Convert.ToInt32(tema * genero / plataforma * pesquisa);
                design = design + Convert.ToInt32(plataforma * genero / tema * pesquisa);
                tecnologia = tecnologia + Convert.ToInt32(genero * plataforma / pesquisa * tema);
                pesquisa = pesquisa + Convert.ToInt32(pesquisa * plataforma / genero * tema);
                System.Threading.Thread.Sleep(3000);
            }

        }

        public void calcula_Tema_Genero_Plataforma_grafico(double tema, double genero, double plataforma, double pesquisa, int faixaEtaria)
        {//Criando o jogo com configurações iniciais com faixa etaria caso já tenha
            for (int i = 0; i < 5; i++)
            {
                erro = erro + Convert.ToInt32((tema * genero / plataforma * pesquisa) + faixaEtaria / 2);
                design = design + Convert.ToInt32((plataforma * genero / tema * pesquisa) + faixaEtaria / 2);
                tecnologia = tecnologia + Convert.ToInt32((genero * plataforma / pesquisa * tema) + faixaEtaria / 2);
                pesquisa = pesquisa + Convert.ToInt32((pesquisa * plataforma / genero * tema) + faixaEtaria / 2);
                System.Threading.Thread.Sleep(3000);
            }

        }

        public void calcula_Tema_Genero_Plataforma_grafico(double tema, double genero, double plataforma, double pesquisa, int faixaEtaria, int engine)
        {//Criando o jogo com configurações iniciais com faixa etaria e engine caso ja tenha
            for (int i = 0; i < 5; i++)
            {
                erro = erro + Convert.ToInt32((tema * genero / plataforma * pesquisa) + faixaEtaria / pesquisa);
                design = design + Convert.ToInt32((plataforma * genero / tema * pesquisa) + faixaEtaria / pesquisa);
                tecnologia = tecnologia + Convert.ToInt32((genero * plataforma / pesquisa * tema) + faixaEtaria / pesquisa);
                pesquisa = pesquisa + Convert.ToInt32((pesquisa * plataforma / genero * tema) + faixaEtaria / pesquisa);
                System.Threading.Thread.Sleep(3000);
            }

        }

        public void calcula_Engine_Jogabilida_Historia(double engine, double jogabilidade, double historia)
        {//Ainda criando o jogo de acordo com porcentagem em engine, jogabilidade e historia
            for (int i = 0; i < 5; i++)
            {
                erro = erro + Convert.ToInt32(engine * jogabilidade / historia * 2);
                design = design + Convert.ToInt32(engine * historia / jogabilidade * 2);
                tecnologia = tecnologia + Convert.ToInt32(historia * jogabilidade / engine * 2);
                pesquisa = pesquisa + Convert.ToInt32(historia * engine / jogabilidade * 2);
                System.Threading.Thread.Sleep(3000);
            }
        }

        public void calcula_Dialogo_Design_IA(double dialogo, double design, double iA)
        {//Ainda criando o jogo de acordo com porcentagem em dialogo, design e IA
            for (int i = 0; i < 5; i++)
            {
                erro = erro + Convert.ToInt32(iA * design / dialogo * 2);
                design = design + Convert.ToInt32(iA * dialogo / design * 2);
                tecnologia = tecnologia + Convert.ToInt32(dialogo * design / iA * 2);
                pesquisa = pesquisa + Convert.ToInt32(dialogo * iA / design * 2);
                System.Threading.Thread.Sleep(3000);
            }
        }

        public void calcula_DesignMundo_grafico_Som(double designMundo, double grafico, double som)
        {//Ainda criando o jogo de acordo com porcentagem em design do Mundo, tipo de grafico e sons
            for (int i = 0; i < 5; i++)
            {
                erro = erro + Convert.ToInt32(som * grafico / designMundo * 2);
                design = design + Convert.ToInt32(som * designMundo / grafico * 2);
                tecnologia = tecnologia + Convert.ToInt32(designMundo * grafico / som * 2);
                pesquisa = pesquisa + Convert.ToInt32(designMundo * som / grafico * 2);
                System.Threading.Thread.Sleep(3000);
            }
            calculaAvaliacao();//calcula a avaliação
            zerarProducao();//zera erro, design e tecnologia ao final dos jogos.
        }

        public void calculaAvaliacao()//Avalia o jogo
        {//apos mostrar as avaliações é necessario zerar*****
            starGames = Convert.ToInt32((pesquisa / erro) / design * tecnologia);
            informedgamer = Convert.ToInt32((pesquisa / erro) / design + 1 * tecnologia);
            gameHero = Convert.ToInt32((pesquisa / erro) / design + 2 * tecnologia);
            allGames = Convert.ToInt32((pesquisa / erro) / design * tecnologia + 3);
        }

        public void zerarProducao() //Isto roda ao final de cada Jogo
        {
            erro = 0;
            design = 0;
            tecnologia = 0;
        }


    }
}
