var express = require('express');
var router = express.Router();

/* Just serve index.html and let Angular figure it out */
router.get('/*', function(req, res, next) {
  res.sendFile("index.html", {root: 'public'});
});

module.exports = router;
