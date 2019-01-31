﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgendaTelefonica.Domain.Entities.Validations {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AgendaTelefonica.Domain.Entities.Validations.ValidationMessages", typeof(ValidationMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O E-mail deve possuir uma classificação..
        /// </summary>
        internal static string ClassificacaoEmailObrigatoria {
            get {
                return ResourceManager.GetString("ClassificacaoEmailObrigatoria", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Telefone deve possuir uma classificação..
        /// </summary>
        internal static string ClassificacaoTelefoneObrigatoria {
            get {
                return ResourceManager.GetString("ClassificacaoTelefoneObrigatoria", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DDD é obrigatório..
        /// </summary>
        internal static string DDDTelefoneObrigatorio {
            get {
                return ResourceManager.GetString("DDDTelefoneObrigatorio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O endereço de e-mail deve ser preenchido..
        /// </summary>
        internal static string EnderecoEmailDeveSerPreenchido {
            get {
                return ResourceManager.GetString("EnderecoEmailDeveSerPreenchido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O endereço de e-mail deve ser válido..
        /// </summary>
        internal static string EnderecoEmailDeveSerValido {
            get {
                return ResourceManager.GetString("EnderecoEmailDeveSerValido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nome do contato é obrigátorio..
        /// </summary>
        internal static string NomeContatoObrigatorio {
            get {
                return ResourceManager.GetString("NomeContatoObrigatorio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Número deve possuir pelo menos 8 dígitos..
        /// </summary>
        internal static string NumeroTelefoneDevePossuirPeloMenos8Digitos {
            get {
                return ResourceManager.GetString("NumeroTelefoneDevePossuirPeloMenos8Digitos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Número do Telefone deve ser preenchido..
        /// </summary>
        internal static string NumeroTelefoneDeveSerPreenchido {
            get {
                return ResourceManager.GetString("NumeroTelefoneDeveSerPreenchido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Telefone do contato é obrigatório..
        /// </summary>
        internal static string TelefoneContatoObrigatorio {
            get {
                return ResourceManager.GetString("TelefoneContatoObrigatorio", resourceCulture);
            }
        }
    }
}
