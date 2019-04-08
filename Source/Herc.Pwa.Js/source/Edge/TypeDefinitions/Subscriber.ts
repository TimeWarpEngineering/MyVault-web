//export type Subscriber<Events: {} = { }> = <Name: $Keys < Events >> (
//  name: Name,
//    f: (v: $ElementType<Events, Name>) => mixed
//) => CallbackRemover

export type CallbackRemover = () => {}

type SomeWatchFunction = (v: any) => {};

export type Subscriber<Events> = (name: string, f: SomeWatchFunction) => CallbackRemover;

//export interface Subscriber<Events extends {} = {}> = <Name: keyof Events>(
//  name: Name,
//  f: (v: Events[name]) => {}
//) => CallbackRemover

type NumberCallback = (n: number) => CallbackRemover;