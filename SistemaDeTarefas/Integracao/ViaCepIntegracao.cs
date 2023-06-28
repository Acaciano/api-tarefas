using SistemaDeTarefas.Integracao.Interfaces;
using SistemaDeTarefas.Integracao.Refit;
using SistemaDeTarefas.Integracao.Response;

namespace SistemaDeTarefas.Integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;
        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
        {
            _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }

        public async Task<ViaCepResponse> ObterDadosCep(string cep)
        {
           var response = await _viaCepIntegracaoRefit.ObterDadosCep(cep);

            if(response != null && response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }
    }
}
