// REGULAR FRAMES
// (n), (n, m)
// n = 10 -> strike
// n < 10 -> single roll
// n + m = 10 -> spare
// n + m < 10 -> open
// n > 10 or
// m > 10 or
// n + m > 10 -> invalid

// FINAL FRAME
// (n), (n, m), (n, m, o)
// n = 10 -> strike
// n < 10 -> single roll
// n + m = 10 -> spare
// n = 10 AND m = 10 -> strike, strike

#[derive(Debug, PartialEq, Eq)]
pub enum Error {
    NotEnoughPinsLeft,
    GameComplete,
}

// #[derive(Debug, PartialEq, Eq)]
#[derive(Debug)]
enum RegularFramePhase {
    FirstRoll,
    SecondRoll { pins_remaining: u16 },
}

#[derive(Debug)]

enum TenthFramePhase {
    FirstRoll,
    SecondRoll { pins_remaining: u16 },
    BonusRoll { pins_remaining: u16 },
}

#[derive(Debug)]
enum FramePhase {
    RegularFramePhase(RegularFramePhase),
    TenthFramePhase(TenthFramePhase),
}

#[derive(Debug)]
pub struct BowlingGame {
    rolls: Vec<u16>,
    frame_count: u16, // 1..=10
    frame_phase: FramePhase,
    is_game_complete: bool,
}

// NOTE:
// - separate tenth frame logic out entirely.
// - consolidate frame phase logic
impl BowlingGame {
    pub fn new() -> Self {
        BowlingGame {
            rolls: Vec::new(),
            frame_count: 1,
            frame_phase: FramePhase::RegularFramePhase(RegularFramePhase::FirstRoll),
            is_game_complete: false,
        }
    }

    pub fn roll(&mut self, pins: u16) -> Result<(), Error> {
        if pins > 10 {
            return Err(Error::NotEnoughPinsLeft);
        }

        if self.is_game_complete {
            return Err(Error::GameComplete);
        }

        match self.frame_phase {
            FramePhase::RegularFramePhase(RegularFramePhase::FirstRoll) => {
                self.rolls.push(pins);

                if pins == 10 {
                    self.frame_count += 1;
                    if self.frame_count == 10 {
                        self.frame_phase = FramePhase::TenthFramePhase(TenthFramePhase::FirstRoll);
                    } else {
                        self.frame_phase =
                            FramePhase::RegularFramePhase(RegularFramePhase::FirstRoll);
                    }
                } else {
                    self.frame_phase =
                        FramePhase::RegularFramePhase(RegularFramePhase::SecondRoll {
                            pins_remaining: 10 - pins,
                        });
                }
            }
            FramePhase::RegularFramePhase(RegularFramePhase::SecondRoll { pins_remaining }) => {
                if pins > pins_remaining {
                    return Err(Error::NotEnoughPinsLeft);
                }

                self.rolls.push(pins);

                self.frame_count += 1;

                if self.frame_count == 10 {
                    self.frame_phase = FramePhase::TenthFramePhase(TenthFramePhase::FirstRoll);
                } else {
                    self.frame_phase = FramePhase::RegularFramePhase(RegularFramePhase::FirstRoll);
                }
            }
            FramePhase::TenthFramePhase(TenthFramePhase::FirstRoll) => {
                self.rolls.push(pins);
                self.frame_phase = FramePhase::TenthFramePhase(TenthFramePhase::SecondRoll {
                    pins_remaining: if pins == 10 { 10 } else { 10 - pins },
                });
            }
            FramePhase::TenthFramePhase(TenthFramePhase::SecondRoll { pins_remaining }) => {
                if pins > pins_remaining {
                    return Err(Error::NotEnoughPinsLeft);
                }

                let is_open =
                    pins_remaining - pins > 0 && self.rolls.last().is_some_and(|roll| *roll < 10);
                self.rolls.push(pins);
                if is_open {
                    self.is_game_complete = true;
                } else {
                    self.frame_phase = FramePhase::TenthFramePhase(TenthFramePhase::BonusRoll {
                        pins_remaining: if pins_remaining - pins == 0 {
                            10
                        } else {
                            pins_remaining - pins
                        },
                    });
                }
            }
            FramePhase::TenthFramePhase(TenthFramePhase::BonusRoll { pins_remaining }) => {
                if pins > pins_remaining {
                    return Err(Error::NotEnoughPinsLeft);
                }

                self.rolls.push(pins);
                self.is_game_complete = true;
            }
        }

        Ok(())
    }

    pub fn score(&self) -> Option<u16> {
        if self.is_game_complete {
            let mut score: u16 = 0;
            let mut i: usize = 0;

            for _frame in 0..10 {
                match self.rolls[i] {
                    // NOTE: very likely to panic on an invalid set of rolls
                    10 => {
                        // write this to check whether we're in the last frame?
                        score += 10
                            + self.rolls.get(i + 1).unwrap_or(&0)
                            + self.rolls.get(i + 2).unwrap_or(&0);
                        i += 1;
                    }
                    first_roll => {
                        let second_roll = self.rolls[i + 1];
                        let frame_total = first_roll + second_roll;
                        if frame_total == 10 {
                            score += frame_total + self.rolls.get(i + 2).unwrap_or(&0);
                        } else {
                            score += frame_total;
                        }
                        i += 2;
                    }
                }
            }

            Some(score)
        } else {
            None
        }
    }
    // fn advance_frame(&mut self) {
    //     // TODO: consolidate frame phase logic in one place
    //     if self.frame_count == 10 {
    //         self.frame_phase = RegularFramePhase::TenthBonusRolls(2);
    //     } else {
    //         self.frame_count += 1;
    //         self.frame_phase = RegularFramePhase::FirstRoll;
    //     }
    // }
}
