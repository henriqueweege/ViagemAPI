﻿using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto
{
    public class LinhaDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Origem { get; set; }
        [Required]
        public string Destino { get; set; }
    }
}
