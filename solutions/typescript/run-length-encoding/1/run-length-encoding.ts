export const encode = (input: string) =>
  input.replace(/(\D)\1+/g, m => `${String(m.length)}${m.charAt(0)}`);

export const decode = (input: string) =>
  input.replace(/(\d+)(\D)/g, (_completeMatch, count, character) =>
    character.repeat(count)
  );
