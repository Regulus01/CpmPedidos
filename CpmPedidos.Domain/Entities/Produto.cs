﻿using CpmPedidos.Domain.Interfaces;

namespace CpmPedidos.Domain.Entities;

public class Produto : BaseDomain, IExibivel
{
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public virtual List<Imagem> imagens { get; set; }
    public bool Ativo { get; set; }
    
    public int IdCategoria { get; set; }
    public virtual CategoriaProduto Categoria { get; set; }
    
}