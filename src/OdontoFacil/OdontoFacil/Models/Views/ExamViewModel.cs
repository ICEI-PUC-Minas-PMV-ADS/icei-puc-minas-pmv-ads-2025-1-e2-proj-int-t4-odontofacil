using OdontoFacil.Models.Data;

namespace OdontoFacil.Models.Views

{

  public class ExamViewModelItem
  {

    public ExamViewModelItem(Data.ExamRequest examRequest)
    {
      Id = examRequest.Id;
      RequestDate = examRequest.RequestDate;
      Patient = examRequest.Patient?.User?.Name;
      Dentist = examRequest.Dentist?.User?.Name;
      Type = examRequest.TypeNavigation?.Description;
      Result = examRequest.Result;
    }

    public string Id { get; set; }
    public DateOnly RequestDate { get; set; }
    public string? Patient { get; set; }
    public string? Dentist { get; set; }
    public string? Type { get; set; }
    public ExamResult Result { get; set; }
  }

  public class ExamViewModel
  {

    public ExamViewModel(IEnumerable<Data.ExamRequest> examRequests)
    {
      Exams = examRequests.Select(er => new ExamViewModelItem(er)).ToList();
    }

    public IEnumerable<ExamViewModelItem> Exams { get; set; }

    public string? UserId { get; set; }
  }
}