using TestFinBeat.Dapper.Entities;

namespace TestFinBeat.Services.Code
{
    public class CodeService : ICodeService
    {
        private readonly ICodeStorage _codeStorage;

        public CodeService(ICodeStorage codeStorage)
        {
            _codeStorage = codeStorage;
        }

        public async Task<int> AddCodesAsync(List<Dictionary<string, string>> codes, CancellationToken cancellationToken = default)
        {
            var codeEntries = new List<CodeEntity>();
            int index = 1;
            codes = codes
                .OrderBy(dict => int.Parse(dict.Keys.First()))
                .ToList();

            foreach (var codeDic in codes)
            {
                var code = codeDic.First();
                codeEntries.Add(new CodeEntity(index, code.Key, code.Value));
                index++;
            }

            if (await _codeStorage.InsertCodesAsync(codeEntries, cancellationToken))
            {
                return codeEntries.Count;
            }
            return 0;
        }

        public async Task<List<CodeEntity>> GetCodesAsync(CancellationToken cancellationToken = default)
        {
            return await _codeStorage.SelectCodesAsync(cancellationToken);
        }
    }
}
