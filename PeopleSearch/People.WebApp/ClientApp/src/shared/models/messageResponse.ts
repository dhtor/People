//plugins
import * as _ from 'underscore';

export class MessageResponse {
  constructor(msg?: MessageResponse) {
    if (_.isEmpty(msg))
      return;

    this.error = msg.error;
    this.failedValidation = msg.failedValidation;
    this.information = msg.information;
  }
  public error: string = null;
  public failedValidation: string = null;
  public information: string = null;

  public isSuccess(): boolean {
    return this.error === null && this.failedValidation === null && this.information === null;
  }
}

export class messageResponse<T> extends MessageResponse {
  constructor(msg?: messageResponse<T>) {
    super(msg);
    if (_.isEmpty(msg))
      return;

    this.result = msg.result;
  }
  public result: T;

  public isSuccess(): boolean {
    return super.isSuccess();
  }
}
