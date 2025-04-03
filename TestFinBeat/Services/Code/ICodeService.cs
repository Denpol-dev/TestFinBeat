using TestFinBeat.Dapper.Entities;

namespace TestFinBeat.Services.Code
{
    public interface ICodeService
    {
        Task<int> AddCodesAsync(List<Dictionary<string, string>> codes, CancellationToken cancellationToken = default);
        Task<List<CodeEntity>> GetCodesAsync(int? id, int? code, string? value, CancellationToken cancellationToken = default);
    }
}
