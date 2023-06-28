using SistemaDeTarefas.Integracao.Response;

namespace SistemaDeTarefas.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosCep(string cep);
    }
}
