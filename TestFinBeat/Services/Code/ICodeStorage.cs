using TestFinBeat.Dapper.Entities;

namespace TestFinBeat.Services.Code
{
    public interface ICodeStorage
    {
        Task<bool> InsertCodesAsync(List<CodeEntity> codes, CancellationToken cancellationToken = default);
        Task<List<CodeEntity>> SelectCodesAsync(CancellationToken cancellationToken = default);
    }
}
