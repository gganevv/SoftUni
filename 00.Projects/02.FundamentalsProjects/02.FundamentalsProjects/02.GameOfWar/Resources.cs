namespace _02.GameOfWar
{
    public static class Texts
    {
        public const string WELCOME_SCREEN = @"
================================================================================
||                     Welcome to the Game of War!                            ||
||                                                                            ||
|| HOW TO PLAY:                                                               ||
|| + Each of the two players are dealt one half of a shuffled deck of cards.  ||
|| + Each turn, each player draws one card from their deck.                   ||
|| + The player that drew the card with higher value gets both cards.         ||
|| + Both cards return to the winner's deck.                                  ||
|| + If there is a draw, both players place the next three cards face down    ||
||        and then another card face-up. The owner of the higher face-up      ||
||        card gets all the cards on the table.                               ||
||                                                                            ||
|| HOW TO WIN:                                                                ||
|| + The player who collects all the cards wins.                              ||
||                                                                            ||
|| CONTROLS:                                                                  ||
|| + Press [Enter] to draw a new card until we have a winner.                 ||
||                                                                            ||
||                              Have fun!                                     ||
================================================================================";
        public const string WAR = "WAR";
        public const string FIRST_PLAYER_NOT_ENOUGH_CARDS = "First player does not have enough cards to contunue playing...";
        public const string SECOND_PLAYER_NOT_ENOUGH_CARDS = "Second player does not have enough cards to contunue playing...";
        public const string FIRST = "first";
        public const string SECOND = "second";
        public const string SEPARATOR = "================================================================================";
        public const string FIRST_PLAYER_DRAWN = "First player has drawn: ";
        public const string SECOND_PLAYER_DRAWN = "First player has drawn: ";
    }
}