import { sleep, group, check } from "k6";
import http from "k6/http";
import { randomIntBetween } from 'https://jslib.k6.io/k6-utils/1.1.0/index.js';

export const options = {
  stages: [
    { target: 20, duration: "1m" },
    { target: 20, duration: "3m30s" },
    { target: 0, duration: "1m" },
  ],
  thresholds: {
    "http_req_duration": ["p(95) < 100"]
  },
};

export default function main() {
  let response;
  const url = "https://covidca3.azurewebsites.net/";

  group(url, function () {
    response = http.get(url, {
      headers: {
        "upgrade-insecure-requests": "1",
        "sec-ch-ua":
          '" Not A;Brand";v="99", "Chromium";v="96", "Google Chrome";v="96"',
        "sec-ch-ua-mobile": "?0",
        "sec-ch-ua-platform": '"Windows"',
      },
    });
    check(response, {
    "is successful": (r) => r.status >= 200 && r.status < 300
    });

    const vars = {"__RequestVerificationToken": response
      .html()
      .find("input[name=__RequestVerificationToken]")
      .first()
      .attr("value")};

    sleep(0.3);

    response = http.post(
      url,
      {
        "VaccineEligibility.Name": "",
        "VaccineEligibility.Age": randomIntBetween(10, 100),
        "VaccineEligibility.Gender": randomIntBetween(0,4),
        __RequestVerificationToken: `${vars["__RequestVerificationToken"]}`,
      },
      {
        headers: {
          "content-type": "application/x-www-form-urlencoded",
          origin: "https://covidca3.azurewebsites.net",
          "upgrade-insecure-requests": "1",
          "sec-ch-ua":
            '" Not A;Brand";v="99", "Chromium";v="96", "Google Chrome";v="96"',
          "sec-ch-ua-mobile": "?0",
          "sec-ch-ua-platform": '"Windows"',
        },
      }
    );

    check(response, {
      "is successful": (r) => r.status >= 200 && r.status < 300
      });
  
  });
}
