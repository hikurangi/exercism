class Words {
  public count(phrase: string=""): Map<string, number> {

    return phrase
      .trim()
      .split(/\s+/)
      .map((word: string): string => word.toLowerCase())
      .reduce((acc: Map<string, number>, word: string): Map<string, number> => {
        
        const existingValue = acc.get(word) || 0
        acc.set(word, existingValue + 1)

        return acc
      }, new Map)

  }
}

export default Words