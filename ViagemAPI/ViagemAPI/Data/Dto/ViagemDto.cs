﻿using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto
{
    public class ViagemDto
    {
        public string NumeroServico { get; set; }
        public int IdLinha { get; set; }
        public int IdMotorista { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataPartida { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataChegada { get; set; }
    }
}
