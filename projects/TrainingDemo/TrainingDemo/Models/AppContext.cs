using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TrainingDemo.Models
{
    /// <summary>
    /// �A�v���P�[�V�����̃f�[�^�x�[�X�R���e�L�X�g�B
    /// </summary>
    public class AppContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}
