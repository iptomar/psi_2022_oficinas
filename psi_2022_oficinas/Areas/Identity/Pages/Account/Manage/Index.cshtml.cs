// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using psi_2022_oficinas.Data;
using psi_2022_oficinas.Models;

namespace psi_2022_oficinas.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        /// <summary>
        /// este atributo representa a base de dados do projeto
        /// </summary>
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [StringLength(14, MinimumLength = 9, ErrorMessage = "O número deve ter entre 9 e 14 caracteres.")]
            [RegularExpression("(00)?([0-9]{2,3})?[1-9][0-9]{8}", ErrorMessage = "Escreva, por favor, um nº de telemóvel com 9 algarismos. Se quiser, pode acrescentar o indicativo nacional e o internacional.")]
            [Display(Name = "Número de Telemóvel")]
            public string PhoneNumber { get; set; }

            ///// <summary>
            ///// Ao anexar um objeto deste tipo ao 'InpuModel' estamos a 
            ///// permitir a recolha dos dados do Cliente
            ///// </summary>
            //public Clientes Cliente { get; set; }

            //#################################################################

            /// <summary>
            /// Nome Próprio do Cliente
            /// </summary>
            [Required(ErrorMessage = "O Nome é de preenchimento obrigatório")]
            [StringLength(50, ErrorMessage = "O primeiro nome não pode conter mais que 50 letras.\n Se for necessário abrevie o seu nome.")]
            [Column("PrimeiroNome")]
            [Display(Name = "Primeiro Nome")]
            public String PrimeiroNome { get; set; }

            /// <summary>
            /// Apelido do Cliente
            /// </summary>
            [Required(ErrorMessage = "O Apelido é de preenchimento obrigatório")]
            [StringLength(50, ErrorMessage = "O primeiro nome não pode conter mais que 50 letras.\n Se for necessário abrevie o seu nome.")]
            [Column("Apelido")]
            [Display(Name = "Apelido")]
            public String Apelido { get; set; }

            /// <summary>
            /// Nome do Cliente
            /// </summary>
            public String NomeCliente
            {
                get { return PrimeiroNome + " " + Apelido; }
            }

            /// <summary>
            /// Data de Nascimento do Cliente
            /// </summary>
            [Required(ErrorMessage = "Data de Nascimento obrigatória")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Data de Nascimento")]
            public DateTime DataNasc { get; set; }

            /// <summary>
            /// Email do Cliente
            /// </summary>
            public String Email { get; set; }

            /// <summary>
            /// NIF do Cliente
            /// </summary>
            [Required(ErrorMessage = "Deve escrever o Número de Identificação Fiscal.")]
            [StringLength(9, ErrorMessage = "O número deve conter {1} caracteres.")]
            [RegularExpression("[1-9]+[0-9]{8}", ErrorMessage = "Escreva, por favor, um nº de cartão de cidadão válido.")]
            [Display(Name = "Número de Identificação Fiscal (NIF)")]
            public String NIF { get; set; }

            /// <summary>
            /// Número da Carta de Condução do Cliente
            /// </summary>
            [Required(ErrorMessage = "Deve escrever a número da Carta de Condução.")]
            [StringLength(9, ErrorMessage = "O número deve conter {1} caracteres.")]
            [RegularExpression("[1-9][0-9]{8}", ErrorMessage = "Escreva, por favor, um nº de Carta de Condução válido.")]
            [Display(Name = "Número de Cartão de Condução")]
            public String NCartaConducao { get; set; }

            /// <summary>
            /// Morada do Cliente
            /// </summary>
            [Required(ErrorMessage = "A Morada é de preenchimento obrigatório")]
            [StringLength(60, ErrorMessage = "A morada não pode ter mais de 60 caracteres.")]
            public String Morada { get; set; }

            /// <summary>
            /// Código Postal do Cliente
            /// </summary>
            [Required(ErrorMessage = "Deve escrever o código postal")]
            [StringLength(30, MinimumLength = 8, ErrorMessage = "O código postal deve ter entre 30 e 8 caracteres.")]
            [Display(Name = "Código Postal")]
            public String CodPostal { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var roleUser = await _userManager.GetRolesAsync(user);

            if (roleUser.Contains("Cliente"))
            {

                var cliente = await _context.Clientes.Where(c => c.UserName == _userManager.GetUserId(User)).FirstOrDefaultAsync();

                Username = userName;

                Input = new InputModel
                {
                    PhoneNumber = cliente.Ntelemovel,
                    PrimeiroNome = cliente.PrimeiroNome,
                    Apelido = cliente.Apelido,
                    DataNasc = cliente.DataNasc,
                    Morada = cliente.Morada,
                    CodPostal = cliente.CodPostal,
                    NIF = cliente.NIF,
                    NCartaConducao = cliente.NCartaConducao,
                    Email = cliente.Email
                };
            }
            else
            {
                Username = userName;

                Input = new InputModel
                {
                    PhoneNumber = phoneNumber,
                    Email = user.Email
                };
            }


        }

        //######################################################

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            // se chego aqui , o Modelo é válido
            // temos de atualizar os  dados na BD

            // atualizar os dados do nº de telefone
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var mail = await _userManager.GetEmailAsync(user);
            if (Input.Email != mail)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (user.EmailConfirmed != true) user.EmailConfirmed = true; ;
                var setUserName = await _userManager.SetUserNameAsync(user, Input.Email);
                if (!setEmailResult.Succeeded && setUserName.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set email.";
                    return RedirectToPage();
                }
            }

            // atualizar os dados na tabela do Cliente

            // recuperar os dados armazenados na BD
            int idClienteAutenticado = (await _context.Clientes.Where(c => c.UserName == _userManager.GetUserId(User)).FirstOrDefaultAsync()).IdClientes;

            var cliente = await _context.Clientes
                                        .Where(c => c.UserName == _userManager.GetUserId(User))
                                        .FirstOrDefaultAsync();
            if (cliente != null)
            {
                // actualizar os dados
                cliente.Ntelemovel = Input.PhoneNumber;
                cliente.PrimeiroNome = Input.PrimeiroNome;
                cliente.Apelido = Input.Apelido;
                cliente.DataNasc = Input.DataNasc;
                cliente.Morada = Input.Morada;
                cliente.CodPostal = Input.CodPostal;
                cliente.NIF = Input.NIF;
                cliente.NCartaConducao = Input.NCartaConducao;
                cliente.Email = Input.Email;

                // prepara para guardar os dados na bd
                _context.Update(cliente);
                // guarda os dados na bd
                await _context.SaveChangesAsync();
            }




            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "O seu perfil foi atualizado com sucesso!";
            return RedirectToPage();
        }
    }
}
