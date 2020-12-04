using System.Collections.Generic;

namespace Dell.Academy.Application.ViewModels
{
    public class ErrorViewModel
    {
        public List<string> Errors { get; set; }

        public ErrorViewModel(List<string> erros) => Errors = erros;
    }
}