namespace NavixCaseStudy.CaseStudyApiWrapper.DTOs.Abstract;

public class ResultsDTO<TItem, TSearchCriteria>
{
    public int Count { get; set; }
    public string Message { get; set; } = string.Empty;
    public TSearchCriteria? SearchCriteria { get; set; } = default;
    public IEnumerable<TItem>? Results { get; set; } = default;
}
