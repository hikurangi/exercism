let twoFer = name => {
  "One for " ++ Belt.Option.getWithDefault(name, "you") ++ ", one for me.";
};