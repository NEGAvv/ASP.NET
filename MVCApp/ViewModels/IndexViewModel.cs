using MVCApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.ViewModels
{
    public record class IndexViewModel( IEnumerable<User> Users);

   }
    