using PinaColada;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;

[assembly: RegisterValidator(typeof(ParticleSystemRendererValidator))]

namespace PinaColada
{
    internal sealed class ParticleSystemRendererValidator : RootObjectValidator<ParticleSystemRenderer>
    {
        protected override void Validate(ValidationResult result)
        {
            ValidateSharedMaterial(Value, result);
        }

        private static void ValidateSharedMaterial(Renderer renderer, ValidationResult result)
        {
            if (renderer.enabled)
            {
                return;
            }

            if (renderer.sharedMaterial == null)
            {
                return;
            }

            result.AddWarning("Unused \"sharedMaterial\" property!").WithFix(() =>
            {
                renderer.sharedMaterial = null;
            });
        }
    }
}
