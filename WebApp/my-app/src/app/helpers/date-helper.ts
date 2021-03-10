const moment = require('moment');

export class DateHelper {
  static convertDateToReadableString(date: Date): string{
    return moment(date).format('DD/MM/YYYY');
  }
}
