type Flatten<T> = T extends Record<string, infer U>
  ? U extends Record<string, any>
    ? Flatten<U>
    : T[keyof T]
  : T
