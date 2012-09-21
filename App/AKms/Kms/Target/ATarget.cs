using Me.Amon.Kms.Enums;
using Me.Amon.Kms.Target.App;
using Me.Amon.Kms.Target.Img;
using Me.Amon.Kms.Target.Man;
using Me.Amon.Kms.Target.Scb;

namespace Me.Amon.Kms.Target
{
    public abstract class ATarget
    {
        public static ITarget ManTarget = new ManTarget();

        public static ITarget AppTarget = new AppTarget();

        public static ITarget ImgTarget = new ImgTarget();

        public static ITarget ScbTarget = new ScbTarget();

        public static ITarget NetTarget;

        public static ITarget KmsTarget;

        public static ITarget GetTarget(ETarget target)
        {
            switch (target)
            {
                case ETarget.Man:
                    return ManTarget;
                case ETarget.App:
                    return AppTarget;
                case ETarget.Scb:
                    return ScbTarget;
                case ETarget.Net:
                    return NetTarget;
                case ETarget.Kms:
                    return KmsTarget;
                case ETarget.Img:
                    return ImgTarget;
                default:
                    return null;
            }
        }
    }
}
