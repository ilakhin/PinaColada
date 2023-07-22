using PinaColada;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;

[assembly: RegisterValidator(typeof(ParticleSystemValidator))]

namespace PinaColada
{
    internal sealed class ParticleSystemValidator : RootObjectValidator<ParticleSystem>
    {
        protected override void Validate(ValidationResult result)
        {
            ValidateShapeMesh(result, Value.shape);
            ValidateShapeMeshRenderer(result, Value.shape);
            ValidateShapeSkinnedMeshRenderer(result, Value.shape);
            ValidateShapeSprite(result, Value.shape);
            ValidateShapeSpriteRenderer(result, Value.shape);
            ValidateTextureSheetAnimationSprites(result, Value.textureSheetAnimation);
            ValidateLightsLight(result, Value.lights);
        }

        private static void ValidateShapeMesh(ValidationResult result, ParticleSystem.ShapeModule shape)
        {
            var allowable = shape is { enabled: true, shapeType: ParticleSystemShapeType.Mesh };

            if (allowable)
            {
                return;
            }

            if (shape.mesh == null)
            {
                return;
            }

            result.AddWarning("Unused \"mesh\" property in Shape module!").WithFix(() =>
            {
                shape.mesh = null;
            });
        }

        private static void ValidateShapeMeshRenderer(ValidationResult result, ParticleSystem.ShapeModule shape)
        {
            var allowable = shape is { enabled: true, shapeType: ParticleSystemShapeType.MeshRenderer };

            if (allowable)
            {
                return;
            }

            if (shape.meshRenderer == null)
            {
                return;
            }

            result.AddWarning("Unused \"meshRenderer\" property in Shape module!").WithFix(() =>
            {
                shape.meshRenderer = null;
            });
        }

        private static void ValidateShapeSkinnedMeshRenderer(ValidationResult result, ParticleSystem.ShapeModule shape)
        {
            var allowable = shape is { enabled: true, shapeType: ParticleSystemShapeType.SkinnedMeshRenderer };

            if (allowable)
            {
                return;
            }

            if (shape.skinnedMeshRenderer == null)
            {
                return;
            }

            result.AddWarning("Unused \"skinnedMeshRenderer\" property in Shape module!").WithFix(() =>
            {
                shape.skinnedMeshRenderer = null;
            });
        }

        private static void ValidateShapeSprite(ValidationResult result, ParticleSystem.ShapeModule shape)
        {
            var allowable = shape is { enabled: true, shapeType: ParticleSystemShapeType.Sprite };

            if (allowable)
            {
                return;
            }

            if (shape.sprite == null)
            {
                return;
            }

            result.AddWarning("Unused \"sprite\" property in Shape module!").WithFix(() =>
            {
                shape.sprite = null;
            });
        }

        private static void ValidateShapeSpriteRenderer(ValidationResult result, ParticleSystem.ShapeModule shape)
        {
            var allowable = shape is { enabled: true, shapeType: ParticleSystemShapeType.SpriteRenderer };

            if (allowable)
            {
                return;
            }

            if (shape.spriteRenderer == null)
            {
                return;
            }

            result.AddWarning("Unused \"spriteRenderer\" property in Shape module!").WithFix(() =>
            {
                shape.spriteRenderer = null;
            });
        }

        private static void ValidateTextureSheetAnimationSprites(ValidationResult result, ParticleSystem.TextureSheetAnimationModule textureSheetAnimation)
        {
            var allowable = textureSheetAnimation is { enabled: true, mode: ParticleSystemAnimationMode.Sprites };

            if (allowable)
            {
                return;
            }

            for (int i = 0, j = textureSheetAnimation.spriteCount; i < j; i++)
            {
                var sprite = textureSheetAnimation.GetSprite(i);

                if (sprite == null)
                {
                    continue;
                }

                var spriteIndex = i;

                result.AddWarning($"Unused \"sprite[{spriteIndex}]\" property in TextureSheetAnimation module!").WithFix(() =>
                {
                    textureSheetAnimation.SetSprite(spriteIndex, null);
                });
            }
        }

        private static void ValidateLightsLight(ValidationResult result, ParticleSystem.LightsModule lights)
        {
            var allowable = lights is { enabled: true };

            if (allowable)
            {
                return;
            }

            if (lights.light == null)
            {
                return;
            }

            result.AddWarning("Unused \"light\" property in Lights module!").WithFix(() =>
            {
                lights.light = null;
            });
        }
    }
}
