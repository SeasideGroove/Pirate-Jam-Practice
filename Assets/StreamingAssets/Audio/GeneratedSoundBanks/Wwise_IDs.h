/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID ENEMY_CRAYONHIT = 414206859U;
        static const AkUniqueID ENEMY_FOOTSTEPSOFF = 2413635886U;
        static const AkUniqueID ENEMY_FOOTSTEPSON = 3921616528U;
        static const AkUniqueID ENEMY_HITPLAYERKNIFE = 4279108229U;
        static const AkUniqueID ENEMY_HITPLAYERMELEE = 809636346U;
        static const AkUniqueID ENEMY_SWORDHIT = 275781020U;
        static const AkUniqueID ENV_PILLOWDROP = 753173717U;
        static const AkUniqueID GAME_OVER = 1432716332U;
        static const AkUniqueID GAME_START = 733168346U;
        static const AkUniqueID PC_FORESTFOOTSTEPSOFF = 3024685458U;
        static const AkUniqueID PC_FORESTFOOTSTEPSON = 596498100U;
        static const AkUniqueID PC_PILLOWDISARM = 1328694536U;
        static const AkUniqueID PC_SWORDSWING = 1094486518U;
        static const AkUniqueID PC_THROWCRAYON = 2407453025U;
        static const AkUniqueID PLAY_BGM = 3126765036U;
        static const AkUniqueID WAVE1_START = 1556374634U;
        static const AkUniqueID WAVE2_START = 3770510345U;
        static const AkUniqueID WAVE3_START = 3819612116U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace PLAYER_LIFE
        {
            static const AkUniqueID GROUP = 3762137787U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace PLAYER_LIFE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace BGM_SWITCH
        {
            static const AkUniqueID GROUP = 1239043692U;

            namespace SWITCH
            {
                static const AkUniqueID GAMEOVER = 4158285989U;
                static const AkUniqueID GAMESTART = 4058101365U;
            } // namespace SWITCH
        } // namespace BGM_SWITCH

        namespace PARANOIA_WAVE
        {
            static const AkUniqueID GROUP = 309484736U;

            namespace SWITCH
            {
                static const AkUniqueID START = 1281810935U;
                static const AkUniqueID WAVE1 = 2453122375U;
                static const AkUniqueID WAVE2 = 2453122372U;
                static const AkUniqueID WAVE3 = 2453122373U;
                static const AkUniqueID WIN = 979765101U;
            } // namespace SWITCH
        } // namespace PARANOIA_WAVE

        namespace PLAYER_HEALTH
        {
            static const AkUniqueID GROUP = 215992295U;

            namespace SWITCH
            {
                static const AkUniqueID DYING = 3328495488U;
                static const AkUniqueID FULL = 2510516222U;
                static const AkUniqueID HURT = 3193947170U;
                static const AkUniqueID INJURED = 2860195132U;
                static const AkUniqueID LASTSTAND = 1787458291U;
                static const AkUniqueID SCRATCHED = 841458286U;
            } // namespace SWITCH
        } // namespace PLAYER_HEALTH

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID CELTICFAIRY_SIDECHAIN = 3966155101U;
        static const AkUniqueID CONTRABASS_SIDECHAIN = 2810791370U;
        static const AkUniqueID CYCLOSA_SIDECHAIN = 3172951054U;
        static const AkUniqueID GLITCHSYNTH_SIDECHAIN = 3044956269U;
        static const AkUniqueID MUSIC_VOLUMESLIDER = 3415784672U;
        static const AkUniqueID PLAYER_HEALTH = 215992295U;
        static const AkUniqueID SEFFECTS_VOLUMESLIDER = 575395640U;
        static const AkUniqueID TANKPIANO_SIDECHAIN = 489317449U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID PLAYER_DEATH = 3083087645U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID DYNAMICMUSIC = 376085973U;
        static const AkUniqueID SOUNDEFFECTS = 3898083304U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID BASSDRUM = 3567020976U;
        static const AkUniqueID BASSINST = 4152426576U;
        static const AkUniqueID CELTICFAIRY = 4225438636U;
        static const AkUniqueID CONTRABASS = 196747927U;
        static const AkUniqueID CYCLOSA = 3237734395U;
        static const AkUniqueID ENEMIES = 2242381963U;
        static const AkUniqueID ENVIRONMENT = 1229948536U;
        static const AkUniqueID GLITCHSYNTH = 2351969468U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC_MASTER_BUS = 495113110U;
        static const AkUniqueID OTHERINSTRUMENTS = 4266000389U;
        static const AkUniqueID PLAYERCHARACTER = 592691923U;
        static const AkUniqueID SOUND_EFFECTS_MASTER_BUS = 3993694368U;
        static const AkUniqueID TANKPIANO = 1135228456U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
