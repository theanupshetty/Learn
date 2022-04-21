const request = require("request-promise");
const cheerio = require("cheerio");
const axios = require("axios");
const { html } = require("cheerio/lib/api/manipulation");
const { response } = require("express");
const res = require("express/lib/response");

const extractLinks = ($) => [
  ...new Set(
    $(".page-numbers a") // Select pagination links
      .map((_, a) => $(a).attr("href")) // Extract the href (url) from each link
      .toArray() // Convert cheerio object to array
  ),
];

module.exports.scraper = axios.get("https://scrapeme.live/shop/").then((data) => {
    const $ = cheerio.load(data); // Initialize cheerio
    const links = extractLinks($);

    console.log(links);
  });
